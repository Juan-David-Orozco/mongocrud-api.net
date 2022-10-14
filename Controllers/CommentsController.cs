using System;
using Microsoft.AspNetCore.Mvc;
using MongoCrud.Models;
using MongoCrud.Services;

namespace MongoCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase 
{
    private readonly MongoDBService _mongoDBService;

    public CommentsController(MongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Comment>> Get() {}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Comment comment) {}

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToComment(string id, [FromBody] string movieId) {}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {}


}
