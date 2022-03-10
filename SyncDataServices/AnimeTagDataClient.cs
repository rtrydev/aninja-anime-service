using aninja_anime_service.Models;
using aninja_tags_service;
using AutoMapper;
using Grpc.Net.Client;

namespace aninja_anime_service.SyncDataServices;

public class AnimeTagDataClient : IAnimeTagDataClient
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AnimeTagDataClient(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }

    public IEnumerable<Anime> ReturnAllAnimeWithTags(IEnumerable<int> tagIds)
    {
        var request = new GetAllWithTagsRequest() {TagId = {tagIds}};
        var channel = GrpcChannel.ForAddress(_configuration["GrpcPlatform"]);
        var client = new GrpcTag.GrpcTagClient(channel);

        var reply = client.GetAllAnimeWithTags(request);
        return _mapper.Map<IEnumerable<Anime>>(reply.Anime);

    }
}