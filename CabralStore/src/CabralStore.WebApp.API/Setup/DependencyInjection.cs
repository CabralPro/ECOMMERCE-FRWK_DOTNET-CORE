using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CabralStore.Catalogo.Application.Services;
using CabralStore.Catalogo.Data;
using CabralStore.Catalogo.Data.Repository;
using CabralStore.Catalogo.Domain;
using CabralStore.Catalogo.Domain.Events;
using CabralStore.Core.Communication.Mediator;
using CabralStore.Core.Messages.CommonMessages.Notifications;
using CabralStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace CabralStore.WebApp.API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
        }
    }
}