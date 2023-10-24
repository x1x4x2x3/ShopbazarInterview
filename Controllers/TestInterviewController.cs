using Microsoft.AspNetCore.Mvc;
using TestInterview.Parameter;
using System.IO;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TestInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestInterviewController : ControllerBase
    {
        private readonly ILogger<TestInterviewController> _logger;

        public TestInterviewController(ILogger<TestInterviewController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Plus")]
        public int Plus([FromBody] PlusParam param)
        {
            var result = param.ValueA + param.ValueB;
            WritePlusFile(result.ToString());
            return result;
        }

        private void WritePlusFile(string content)
        {
            var path = "D:\\sources\\other\\NewTestInterview";
            StreamWriter stream;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            stream = new StreamWriter(path + "\\test.txt", true);
            stream.Write(content);
            stream.Write("\r\n");
            stream.Flush();
            stream.Close();
        }
    }
}