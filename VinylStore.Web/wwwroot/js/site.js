function getArtists(search)
{
	$.ajax({
		url: "https://musicbrainz.org/ws/2/artist/?query=%22" + search.trim() + "%22&limit=5&fmt=json",
		type: 'GET',

		complete: function (result)
		{
			var artists = JSON.parse(result.responseText);

			$("#responseArtists").html("<br />");
			$("#responseAlbums").html("<br />");
			$("#responseTitles").html("<br/>");


			$.ajax({
				type: 'Post',
				contentType: 'application/json; charset=utf-8',
				url: 'Supply/GetArtists',
				data: JSON.stringify(artists.artists),

				success: function (ArtistsView)
				{
					$("#responseArtists").append(ArtistsView);
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
			var albums = JSON.parse(result.responseText);
			$("#responseAlbums").html("<br />");
			$("#responseTitles").html("<br/>");

			$.ajax({
				type: 'Post',
				contentType: 'application/json; charset=utf-8',
				url: 'Supply/GetAlbums',
				data: JSON.stringify(albums.releases),

				success: function (AlbumsView)
				{
					$("#responseAlbums").append(AlbumsView);
				}
			});
		},

		error: function (resultat, status, erreur)
		{
			alert("Erreur : " + erreur);
		}
	});
}

function getTitlesByAlbum(albumId)
{
	$.ajax({
		url: "https://musicbrainz.org/ws/2/release/" + albumId + "?inc=artists+recordings&fmt=json",
		type: 'GET',

		complete: function (result)
		{
			var tracks = JSON.parse(result.responseText);
			$("#responseTitles").html("<br/>");
			var response = JSON.stringify(tracks['media'][0]['tracks']);
			alert(tracks);

			$.ajax({
				type: 'Post',
				dataType: 'Json',
				//contentType: 'application/json; charset=utf-8',
				url: 'Supply/GetTitlesByAlbum',
				data: { response },

				success: function (TitlesView)
				{
					$("#responseTitles").append(TitlesView);
				}
			});
		},

		error: function (resultat, status, erreur)
		{
			alert("Erreur : " + erreur);
		}
	});
}