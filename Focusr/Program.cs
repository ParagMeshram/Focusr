namespace Focusr
{
    using System;
    using System.Windows.Forms;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Timer = System.Timers.Timer;

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var container = CreateContainer())
            {
                container.Configure();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Resolve<MainForm>());
            }
        }

        private static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer();
        }

        private static void Configure(this IWindsorContainer container)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<Form>());
            container.Register(Classes.FromThisAssembly()
                .Where(type => type.IsPublic)
                .WithService.DefaultInterfaces());
            container.Register(Component.For<Timer>());
        }
    }
}