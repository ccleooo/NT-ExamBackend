using Microsoft.AspNetCore.Mvc;
using NetCore.Models.Api;
using NetCore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        // 取得所有資料
        [HttpGet]
        public List<Example> Get()
        {
            return ExampleService.GetAll();
        }

        // 取得單一一筆資料
        [HttpGet("{code}")]
        public Example Get(string code)
        {
            return ExampleService.Get(code);
        }

        // 用於新增
        [HttpPost]
        public void Post([FromBody] Example example)
        {
            ExampleService.Add(example);
        }

        // 用於更新
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // 用於刪除
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
