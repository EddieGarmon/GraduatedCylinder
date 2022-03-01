using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal abstract class Variable<T>
{

    internal Variable(string id) {
        Id = id;
    }

    public string Id { get; }

    public string GetReadCommand() {
        return $"${Id}\r\n";
    }

    public string GetWriteCommand(T newValue) {
        return $"${Id},{Encode(newValue)}\r\n";
    }

    public abstract bool TryDecode(Sentence line, out T value);

    protected abstract string Encode(T value);

}