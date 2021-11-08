using GraduatedCylinder;

namespace Sample.JsonUsage
{
    public class Cube
    {

        public Cube(Length length, Length width, Length height) {
            Length = length;
            Width = width;
            Height = height;
            TopArea = length * width;
            Volume = length * width * height;
        }

        public Length Height { get; }

        public Length Length { get; }

        public Area TopArea { get; }

        public Volume Volume { get; }

        public Length Width { get; }

    }
}