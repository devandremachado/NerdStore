﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Domain.Enums
{
    public enum EPedidoStatus
    {
        Rascunho = 0,
        Iniciado = 1,
        Pago = 2,
        Entregue = 3,
        Cancelado = 4
    }
}
