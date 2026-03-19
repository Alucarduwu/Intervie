using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PanaceaMediaPlayer.Models
{
    // Clase que representa un video o contenido
    public class MediaItem
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("category_id")] public int CategoryId { get; set; }
        [JsonProperty("category_name")] public string CategoryName { get; set; }
        [JsonProperty("thumbnail_url")] public string ThumbnailUrl { get; set; }
        [JsonProperty("stream_url")] public string StreamUrl { get; set; }
        [JsonProperty("duration")] public int Duration { get; set; }
        [JsonProperty("year")] public int Year { get; set; }
        [JsonProperty("rating")] public string Rating { get; set; }
        [JsonProperty("tags")] public string Tags { get; set; }
        [JsonProperty("featured")] public bool Featured { get; set; }
        [JsonProperty("enabled")] public bool Enabled { get; set; }
        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        // Formatear la duración para que se vea bonita
        public string DisplayDuration => $"{Duration / 60}m {Duration % 60}s";
    }

    // Estructura de la respuesta que nos da la API
    public class ContentResponse
    {
        [JsonProperty("items")] public List<MediaItem> Items { get; set; }
        [JsonProperty("total")] public int Total { get; set; }
        [JsonProperty("page")] public int Page { get; set; }
        [JsonProperty("page_size")] public int PageSize { get; set; }
    }
}
