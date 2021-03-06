﻿using System;

namespace JetBrains.Annotations
{
    /// <summary>
    ///     Specify what is considered used implicitly when marked with <see cref="MeansImplicitUseAttribute" /> or
    ///     <see cref="UsedImplicitlyAttribute" />
    /// </summary>
    [Flags]
    internal enum ImplicitUseTargetFlags
    {
        /// <summary>
        ///     The default value
        /// </summary>
        Default = Itself,

        /// <summary>
        ///     Itself
        /// </summary>
        Itself = 1,

        /// <summary>
        ///     Members of entity marked with attribute are considered used
        /// </summary>
        Members = 2,

        /// <summary>
        ///     Entity marked with attribute and all its members considered used
        /// </summary>
        WithMembers = Itself | Members
    }
}