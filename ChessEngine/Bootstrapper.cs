using Autofac;

using ChessEngine.Services;
using ChessEngine.Services.Interfaces;
using ChessEngine.ViewModels;

namespace ChessEngine
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; set; } = null!;

        public static void InitialiseContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ChessGridViewModel>()
                .AsSelf();

            builder.RegisterType<BoardGeneratorService>()
                .As<IBoardGeneratorService>();

            Container = builder.Build();
        }
    }
}
