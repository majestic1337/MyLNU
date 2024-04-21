using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyLNY.ReadModels;
using Newtonsoft.Json;

namespace MyLNY.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : Controller
    {
        private readonly HttpClient _httpClient;

        public NewsController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            try
            {

                var url = "https://lnu.edu.ua/news/all/";

                var html = await _httpClient.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var articleNodes = htmlDoc.DocumentNode.SelectNodes("//article");

                if (articleNodes != null)
                {
                    var articles = new ArticleList();
                    foreach (HtmlNode articleNode in articleNodes)
                    {
                        var sectionNodes = articleNode.SelectNodes(".//section[@class='post with-image clearfix']");
                        foreach (HtmlNode sectionNode in sectionNodes)
                        {
                            string siteLink = sectionNode.SelectSingleNode(".//h2/a")?.Attributes["href"]?.Value;
                            string postTitle = sectionNode.SelectSingleNode(".//h2/a")?.InnerText.Trim();
                            string postExcerpt = sectionNode.SelectSingleNode(".//div[@class='post-excerpt']")?.InnerText.Trim();
                            if (postExcerpt == null) { postExcerpt = string.Empty; }
                            string postDate = sectionNode.SelectSingleNode(".//div[@class='post-date']")?.InnerText;

                            string photoLink = null;
                            var photoNode = sectionNode.SelectSingleNode(".//a[@class='post-thumb']");
                            if (photoNode != null)
                            {
                                var styleAttributeValue = photoNode.GetAttributeValue("style", "");
                                var startIndex = styleAttributeValue.IndexOf("url(") + 4;
                                var endIndex = styleAttributeValue.IndexOf(")");
                                photoLink = styleAttributeValue.Substring(startIndex, endIndex - startIndex);
                            }

                            articles.Articles.Add(new ArticleInfo
                            {
                                SiteLink = siteLink,
                                PhotoLink = photoLink,
                                PostTitle = postTitle,
                                PostExcerpt = postExcerpt,
                                PostDate = postDate
                            });
                        }
                    }

                    string json = JsonConvert.SerializeObject(articles, Formatting.Indented);
                    return Ok(json);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { ErrorMessage = $"Request exception: {e.Message}" });
            }
        }
    }
}
