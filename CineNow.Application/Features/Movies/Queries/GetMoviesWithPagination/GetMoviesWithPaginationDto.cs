﻿using CineNow.Application.Common.Mappings;
using CineNow.Domain.Common.Enums;
using CineNow.Domain.Entities;

public class GetMoviesWithPaginationDto : IMapFrom<Movie>
{
    public int? Id { get; init; }
    public int? Rank { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? Image { get; init; }
    public string? BigImageUrl { get; init; }
    public List<string>? Genre { get; init; }
    public string? ThumbnailUrl { get; init; }
    public string? Rating { get; init; }
    public float? RatingAsNumber { get; init; }
    public int? Year { get; init; }
    public string? ImdbId { get; init; }
    public string? ImdbLink { get; init; }
    public List<Language>? AudioLanguages { get; init; }
    public List<Language>? SubtitleLanguages { get; init; }
}