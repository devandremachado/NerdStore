﻿using NerdStore.Shared.Messages;
using System.Threading.Tasks;

namespace NerdStore.Shared.Bus
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;

    }
}