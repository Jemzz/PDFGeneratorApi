using ImageMagick;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using PDF.Core.Utilities;

namespace PDF.PDFGeneration.Helper
{
    public static class APIRequestHelper
    {
        public static async Task<string> RetrieveImage(this IHtmlHelper htmlHelper, string path, bool isPortrait = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                    return string.Empty;

                var image = await APIRequestHelperInstance.GetInstance.RetrieveImageAsync(path, isPortrait);
                return image;
            }
            catch
            {
                //log error
                return string.Empty;
            }
        }
    }

    public sealed class APIRequestHelperInstance
    {
        private static HttpClient _httpClient;
        private static readonly Lazy<APIRequestHelperInstance> InstanceLock = new Lazy<APIRequestHelperInstance>(() => new APIRequestHelperInstance());

        public static APIRequestHelperInstance GetInstance => InstanceLock.Value;

        public APIRequestHelperInstance()
        {
            var configuration = ConfigurationHelper.AppSetting("Verify:ApiKey");
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", configuration);
        }

        public async Task<string> RetrieveImageAsync(string path, bool isPortrait)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                    return string.Empty;

                var response = await _httpClient.GetAsync(path);

                response.EnsureSuccessStatusCode();
                await using var bytes = await response.Content.ReadAsStreamAsync();
                using var image = new MagickImage(bytes);

                //if (isPortrait)
                //{
                //    image.Rotate(90);
                //}

                return $"data:image/jpg;base64,{image.ToBase64()}";
            }
            catch
            {
                //log error
                return string.Empty;
            }
        }
    }
}
