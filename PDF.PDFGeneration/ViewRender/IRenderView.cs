using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PDF.PDFGeneration.ViewRender
{
    public interface IRenderView
    {
        Task<string> RenderViewToString<TModel>(ControllerContext controllerContext, string viewPath, TModel model);
    }
}
