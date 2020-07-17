function getArtists(search)
{
	$.ajax({
		url: "https://musicbrainz.org/ws/2/artist/?query=" + search + "&limit=5&fmt=json",
		type: 'GET',

		complete: function (result)
		{
			var response = JSON.parse(result.responseText);

			$("#responseArtists").html("<br />");
			$("#responseAlbums").html("<br />");


			$.ajax({
				url: 'Supply/GetArtists',
				type: 'Post',
				data: JSON.stringify(response.artists),
				contentType: 'application/json; charset=utf-8',

				success: function (ArtistCard)
				{
					$("#responseArtists").append(ArtistCard);
				}
			});

		},

		error: function (resultat, status, erreur)
		{
			alert("Erreur : " + erreur);
		}
	});
}

function getAlbums(artistId)
{
	$.ajax({
		url: "https://musicbrainz.org/ws/2/release/?query=arid:" + artistId + "%20AND%20status:official%20AND%20type:album%20AND%20format:*vinyl*&fmt=json",
		type: 'GET',

		complete: function (result)
		{
			var response = JSON.parse(result.responseText);

			$("#responseAlbums").html("<br />");

			$.ajax({
				url: 'Supply/GetAlbums',
				type: 'Post',
				data: JSON.stringify(response.releases),
				contentType: 'application/json; charset=utf-8',

				success: function (AlbumCard)
				{
					$("#responseAlbums").append(AlbumCard);
				}
			});
		},

		error: function (resultat, status, erreur)
		{
			alert("Erreur : " + erreur);
		}
	});
}