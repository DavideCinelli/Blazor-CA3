// Davide Cinelli X00193015 CA3

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JikanBlazorApp.Models
{
    public class AnimeModel
    {
        [JsonPropertyName("mal_id")]
        public int Mal_id { get; set; }
        
        public string? Title { get; set; }
        public string? Title_english { get; set; }
        public string? Title_japanese { get; set; }
        public List<string>? Title_synonyms { get; set; }
        public string? Synopsis { get; set; }
        public string? Background { get; set; }
        public double? Score { get; set; }
        public int? Scored_by { get; set; }
        public int? Rank { get; set; }
        public int? Popularity { get; set; }
        public int? Members { get; set; }
        public int? Favorites { get; set; }
        public string? Type { get; set; }
        public string? Source { get; set; }
        public int? Episodes { get; set; }
        public string? Status { get; set; }
        public bool Airing { get; set; }
        public string? Duration { get; set; }
        public string? Rating { get; set; }

        [JsonPropertyName("images")]
        public Images? Images { get; set; }

        [JsonPropertyName("aired")]
        public Aired? Aired { get; set; }

        [JsonPropertyName("broadcast")]
        public Broadcast? Broadcast { get; set; }

        [JsonPropertyName("trailer")]
        public Trailer? Trailer { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre>? Genres { get; set; }

        [JsonPropertyName("themes")]
        public List<Theme>? Themes { get; set; }

        [JsonPropertyName("producers")]
        public List<Producer>? Producers { get; set; }

        [JsonPropertyName("licensors")]
        public List<Licensor>? Licensors { get; set; }

        [JsonPropertyName("studios")]
        public List<Studio>? Studios { get; set; }
    }

    public class Images
    {
        [JsonPropertyName("jpg")]
        public Jpg? Jpg { get; set; }

        [JsonPropertyName("webp")]
        public Webp? Webp { get; set; }
    }

    public class Jpg
    {
        [JsonPropertyName("image_url")]
        public string? Image_url { get; set; }

        [JsonPropertyName("small_image_url")]
        public string? Small_image_url { get; set; }

        [JsonPropertyName("large_image_url")]
        public string? Large_image_url { get; set; }
    }

    public class Webp
    {
        [JsonPropertyName("image_url")]
        public string? Image_url { get; set; }

        [JsonPropertyName("small_image_url")]
        public string? Small_image_url { get; set; }

        [JsonPropertyName("large_image_url")]
        public string? Large_image_url { get; set; }
    }

    public class Aired
    {
        [JsonPropertyName("from")]
        public DateTime? From { get; set; }

        [JsonPropertyName("to")]
        public DateTime? To { get; set; }

        [JsonPropertyName("prop")]
        public Prop? Prop { get; set; }

        [JsonPropertyName("string")]
        public string? String { get; set; }
    }

    public class Prop
    {
        [JsonPropertyName("from")]
        public From? From { get; set; }

        [JsonPropertyName("to")]
        public To? To { get; set; }
    }

    public class From
    {
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }

    public class To
    {
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }

    public class Broadcast
    {
        public string? Day { get; set; }
        public string? Time { get; set; }
        public string? Timezone { get; set; }
        public string? String { get; set; }
    }

    public class Trailer
    {
        [JsonPropertyName("youtube_id")]
        public string? Youtube_id { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("embed_url")]
        public string? Embed_url { get; set; }

        [JsonPropertyName("images")]
        public TrailerImages? Images { get; set; }
    }

    public class TrailerImages
    {
        [JsonPropertyName("image_url")]
        public string? Image_url { get; set; }

        [JsonPropertyName("small_image_url")]
        public string? Small_image_url { get; set; }

        [JsonPropertyName("medium_image_url")]
        public string? Medium_image_url { get; set; }

        [JsonPropertyName("large_image_url")]
        public string? Large_image_url { get; set; }

        [JsonPropertyName("maximum_image_url")]
        public string? Maximum_image_url { get; set; }
    }

    public class Genre
    {
        [JsonPropertyName("mal_id")]
        public int Mal_id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class Theme
    {
        [JsonPropertyName("mal_id")]
        public int Mal_id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class Producer
    {
        [JsonPropertyName("mal_id")]
        public int Mal_id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class Licensor
    {
        [JsonPropertyName("mal_id")]
        public int Mal_id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class Studio
    {
        [JsonPropertyName("mal_id")]
        public int Mal_id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class AnimeResponse
    {
        [JsonPropertyName("data")]
        public List<AnimeModel>? Data { get; set; }
    }

    public class AnimeDetailResponse
    {
        [JsonPropertyName("data")]
        public AnimeModel? Data { get; set; }
    }
}