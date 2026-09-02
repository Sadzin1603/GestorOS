using GestorOS.Models;

namespace GestorOS.Helpers
{
    public static class StatusExtensions
    {
        public static string ParaTexto(this StatusOrdem status) => status switch
        {
            StatusOrdem.Aberta => "Aberta",
            StatusOrdem.EmAndamento => "Em Andamento",
            StatusOrdem.Concluida => "Concluída",
            StatusOrdem.Cancelada => "Cancelada",
            _ => status.ToString()

        };
        public static string ParaClasseBadge(this StatusOrdem status) => status switch
        {
            StatusOrdem.Aberta => "badge-aberta",
            StatusOrdem.EmAndamento => "badge-andamento",
            StatusOrdem.Concluida => "badge-concluida",
            StatusOrdem.Cancelada => "badge-cancelada",
            _ => "bg-secondary"

        };

        public static string ParaIcone(this StatusOrdem status) => status switch
        {
            StatusOrdem.Aberta => "fa-folder-open",
            StatusOrdem.EmAndamento => "fa-gear",
            StatusOrdem.Concluida => "fa-circle-check",
            StatusOrdem.Cancelada => "fa-circle-xmark",
            _ => "fa-circle"

        };
    }
}
