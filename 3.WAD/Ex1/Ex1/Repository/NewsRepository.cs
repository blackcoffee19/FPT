using AutoMapper;
using Ex1.Data;
using Ex1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex1.Repository
{
    public class NewsRepository
    {
        NewsDbContext ctx;
        IMapper mapper;
        public NewsRepository(NewsDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public async Task<List<NewsDto>> FindAll()
        {
            //return await ctx.News.Select(o=>new NewsDto { Id=o.NewsId,HeadLine=o.HeadLine,ContentOfNews=o.ContentOfNews}).ToListAsync();
            return await ctx.News!.Select(x => mapper.Map<NewsDto>(x)).ToListAsync();
        }
        public async Task Create(NewsDto news)
        {
            News nn= mapper.Map<News>(news);
            ctx.News.Add(nn);
            await ctx.SaveChangesAsync();
        }
        public async Task<NewsDto> FindById(int id)
        {
            News? news = await ctx.News!.FirstOrDefaultAsync(x => x.NewsId == id) ;
            NewsDto? nedto = mapper.Map<NewsDto>(news);
            return nedto;
        }
        public async Task Edit(NewsDto? nw)
        {
            if(nw != null)
            {
                News ne = mapper.Map<News>(nw); 
                ctx.Entry<News>(ne).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }

        }
    }
}
