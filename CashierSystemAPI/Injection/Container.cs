/// <summary>
/// Root namespace
/// </summary>
namespace CashierSystemAPI
{
    // Required namespace
    using Ninject;

    /// <summary>
    /// IoC Container
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Return a new instance of the container
        /// </summary>
        public static Container Instance => new Container();

        /// <summary>
        /// The single instance of the application kernel
        /// </summary>
        public static IKernel ApplicationKernel { get; private set; }

        /// <summary>
        /// Sets up the IoC container
        /// </summary>
        public static void SetupIoC()
        {
            // Construct the kernel
            ApplicationKernel = new StandardKernel().Construct();
        }

        /// <summary>
        /// Returns a class from the <see cref="ApplicationKernel"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class
            =>
            ApplicationKernel.Get<T>();

        /// <summary>
        /// Returns the <see cref="Repository"/>
        /// </summary>
        public static IRepository Repository
            =>
            ApplicationKernel.Get<MSSQL>();
    }
}