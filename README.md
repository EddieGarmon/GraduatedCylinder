# GraduatedCylinder

- A typed implementation of measurable dimensions for .NET (i.e. Length, Speed, Acceleration, Jerk).
- Unit conversions are supported at runtime and for view binding. Many operators are implemented to allow derivative computations without you explicitly worrying about units, it is taken care of for you (i.e. Jerk = Acceleration / Time). 
- Unit conversions are supported by an IUnitConverter interface that can be extended.

### Build
You can build GraduatedCylinder using MS Visual Studio or MonoDevelop. It is recommended that anyone planning to contribute to the project familiarise themselves with the PSake build script as it is he build process for validating pull-requests and package creation.

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
    Acceleration deceleration = ((endSpeed * endSpeed) - (startSpeed * startSpeed)) / (2 * stoppingDistance);
    Force stoppingForceRequired = vehicleMass * deceleration;

    Console.WriteLine("The stopping force required is:");
    Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.Newtons, 3));
    Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.KilogramForce, 3));
    Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.PoundForce, 3));
    
    The output is as follows:
    The stopping force required is:
        -1,561.721 N
        -159.197 kgf
        -351.089 lbf
```
