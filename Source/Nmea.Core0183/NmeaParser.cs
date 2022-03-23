namespace Nmea.Core0183;

public abstract class NmeaParser
{

    private readonly List<Func<Sentence, object?>> _decoders = new();

    protected NmeaParser(IEnumerable<Func<Sentence, object>> decoders) {
        _decoders.AddRange(decoders);
    }

    protected NmeaParser(params Func<Sentence, object?>[] decoders) {
        _decoders.AddRange(decoders);
    }

    public Message? Parse(Sentence? sentence) {
        if (sentence == null) {
            return null;
        }
        int decoderIndex = 0;
        object? decoded = null;
        for (; decoderIndex < _decoders.Count; decoderIndex++) {
            Func<Sentence, object?> decoder = _decoders[decoderIndex];
            decoded = decoder(sentence);
            if (decoded != null) {
                //automatically reorder decoders so that the most used decoders are first in the list
                for (int i = decoderIndex; i > 0; i--) {
                    _decoders[i] = _decoders[i - 1];
                }
                _decoders[0] = decoder;
                break;
            }
        }
        if (decoded == null) {
            //decode failed?
            // Debugger.Break();
            return null;
        }
        return new Message(sentence, decoded);
    }

}