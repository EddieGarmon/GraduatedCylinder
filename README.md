# GraduatedCylinder

- A typed implementation of measurable dimensions for .NET (i.e. Length, Speed, Acceleration, Jerk).
- Unit conversions are supported at runtime and for view binding. Many operators are implemented to allow derivative computations without you explicitly worrying about units, it is taken care of for you (i.e. Jerk = Acceleration / Time). 
- Starting at version 6.0, this library uses Roslyn to generate many features from built in metadata, so no runtime reflection is required anymore.

### Build
You can build GraduatedCylinder using MS Visual Studio 2022. We use [Nuke](https://nuke.build/) as the build engine, and deliver packages on [NuGet.org](https://www.nuget.org/packages?q=GraduatedCylinder)

### Contribute
Contributions to GraduatedCylinder are gratefully received but we do ask you to follow certain conditions:

* Fork the main [eddiegarmon/GraduatedCylinder](http://github.com/eddiegarmon/GraduatedCylinder.git)
* Use a branch when developing in your own forked repository, DO NOT work against master
* Write one or more unit tests to validate new logic, ideally using TDD
* Ensure all projects build and all tests pass
* Make a pull request from `your-fork/your-branch` to `GraduatedCylinder/master`
* Provide a description of the motivation behind the changes

### Versioning
The main contributors to the project will manage releases and [SemVer-compliant](http://semver.org/) version numbers.

### A Simple Sample
```c#
    Mass vehicleMass = new Mass(2500, MassUnit.Pounds);
    Speed startSpeed = new Speed(72, SpeedUnit.MilesPerHour);
    Speed endSpeed = new Speed(0, SpeedUnit.MilesPerHour);
    Length stoppingDistance = new Length(1234, LengthUnit.Feet);
    Acceleration deceleration = MotionCalculator.ComputeConstantAcceleration(startSpeed, endSpeed, stoppingDistance);
    Force stoppingForceRequired = vehicleMass * deceleration;

    Console.WriteLine("The stopping force required is:");
    Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.Newtons, 3));
    Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.KilogramForce, 3));
    Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.PoundForce, 3));
    
    The output is as follows:
    To stop a vehicle of 2,500.00 lbs moving at 72.00 mph within 1,234.00 ft,
    the force required is:
            -1,561.72 N
            -1,561.721 N
            -159.20 kgf
            -351.08893 lbf
```
