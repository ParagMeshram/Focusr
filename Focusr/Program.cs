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
            var container = CreateContainer();

            container.Register(Classes.FromThisAssembly().BasedOn<Form>());
            container.Register(Classes.FromThisAssembly()
                .Where(type => type.IsPublic)
                .WithService.DefaultInterfaces());
            container.Register(Component.For<Timer>());


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());
        }

        private static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer();
        }
    }
}