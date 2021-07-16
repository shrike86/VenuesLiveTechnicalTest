using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VenuesLiveTechnicalTest.Shared.Extensions;
using VenuesLiveTechnicalTest.Shared.Models;
using VenuesLiveTechnicalTest.Web.Contracts;

namespace VenuesLiveTechnicalTest.Web.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly HttpClient _httpClient;

        public InvoiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetInvoicesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/invoice");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            return stream.ReadAndDeserializeFromJson<IEnumerable<InvoiceDTO>>();
        }

        public async Task CreateInvoiceAsync(InvoiceDTO invoice)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/invoice");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var contentStream = new MemoryStream();
            contentStream.SerializeToJsonAndWrite(invoice);
            contentStream.Seek(0, SeekOrigin.Begin);

            using (var streamContent = new StreamContent(contentStream))
            {
                request.Content = streamContent;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }

        }
    }
}
