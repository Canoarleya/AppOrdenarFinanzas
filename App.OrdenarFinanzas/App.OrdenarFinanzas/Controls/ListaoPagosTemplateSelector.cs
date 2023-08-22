using App.OrdenarFinanzas.Data.Models;
using App.OrdenarFinanzas.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.OrdenarFinanzas.Controls
{
    internal class ListaoPagosTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate GastosAhorros { get; set; }
        public DataTemplate GastosFijos { get; set; }

        protected override DataTemplate OnSelectTemplate(object pagoObject, BindableObject container)
        {
            if (!(pagoObject is PagosDto pagosDto))
            {
                return DefaultTemplate;
            }

            switch (pagosDto.IdTipoPago)
            {
                case 1:
                    return GastosAhorros;
                case 2:
                    return GastosFijos;
                default:
                    return DefaultTemplate;
            }
        }
    }
}
