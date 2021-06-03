namespace CashierSystemAPI
{
    // Required namespaces
    using Ninject;
    using System;

    /// <summary>
    /// Contains extensions for Ninject
    /// </summary>
    public static class KernelExtensions
    {
        /// <summary>
        /// Constructs the specified kernel.
        /// </summary>
        /// <typeparam name="IK">The type of the k.</typeparam>
        /// <param name="K">The k.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IK Construct<IK>(this IK K) where IK : IKernel
        {
            // Check if K is null
            if (K == null) throw new ArgumentNullException();

            // All kernel bindings should be done here
            K.Bind<MSSQL>().ToConstant( new MSSQL() ); // Bubd the database connection

            // Return the constructed Kernel
            return K;
        }

    }
}
