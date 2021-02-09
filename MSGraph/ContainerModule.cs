using Autofac;
using MSGraph.Service;
using MSGraph.IService;

namespace MSGraph
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AuthenticationService>()
                .As<IAuthenticationService>();
        }
    }
}
