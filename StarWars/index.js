let test;
async function getMovieDetails() {
    let response = await fetch("https://swapi.dev/api/films/");
    if (response.ok) {
        let json = await response.json();
        test = json;
        showOnPage(json);
    }
}
function showOnPage(films) {
    let countFilms = films.count;
    for (let index = 0; index < countFilms; index++) {
        const film = films.results[index];
        let filmsRow = document.getElementById('filmsRow');
        let cardTitleID = 'cardTitle' + (index + 1);
        let cardCrawlID = 'cardCrawl' + (index + 1);
        let cardDirectorID = 'cardDirector' + (index + 1);
        let buttonID = (index + 1);
        let imgUrl = './media/' + (index + 1) + '.jpg'

        let cardHtml = '<div class="card bg-transparent text-light col-4 border border-1 mt-5 rounded rounded-5">' +
            '<h5 class="card-title text-danger rounded rounded-1 mt-3" id="' + cardTitleID + '"></h5>'+
            '<div class="card-body">' +
            '<img src="' + imgUrl + '" class="card-img-top rounded rounded-5" />' +
            '<p class="card-text text-light rounded rounded-1 mt-3" id="' + cardCrawlID + '"></p>' +
            '<h6 class="card-title text-success rounded rounded-1" id="' + cardDirectorID + '"></h6>' +
            '</div>' +
            '<div class="card-body">' +
            '<button type="submit" class="btn btn-success" onclick="getSummary(event)" id="' + buttonID + '">Get Summary With ChatGPT</button>' +
            '<br><span id="summary' + buttonID + '"></span>' +
            '</div>' +
            '</div>'
        filmsRow.innerHTML = filmsRow.innerHTML + cardHtml;


        document.getElementById(cardTitleID).innerText = film.title;
        document.getElementById(cardCrawlID).innerText = film.opening_crawl;
        document.getElementById(cardDirectorID).innerText = film.director;
    }
}
const API_KEY = 'xxxxxxxxxxxxxxxxxxxxxxxxxx'

async function getSummary(event) {
    let films = test;
    let buttonID = event.target.id;
    
    let spanID = 'summary' + buttonID;
    let title = films.results[(buttonID - 1)].title;

    //Can't use ChatGPT API key right now

    // let question = 'Write a synopsis of the movie Star Wars "'+ title +'". While doing this, do not write anything else as output, just start writing the synopsis'

    // const options = {
    //     method: 'POST',
    //     headers: {
    //         'Authorization': 'Bearer '+ API_KEY,
    //         'Content-Type': 'application/json'
    //     },
    //     body: JSON.stringify({

    //         model: "gpt-3.5-turbo",
    //         messages: [{ role: "user", content: question }],
    //         max_tokens: 100

    //     })
    // }

    // let response =await fetch("https://chatgpt-api.shn.hk/v1/", options);
    // let data = await response.json();
    //document.getElementById(spanID).innerText = data.choices[0].messages.content;
    switch (buttonID) {
        case '1':
            document.getElementById(spanID).innerText = "Star Wars Episode IV: A New Hope is a 1977 American epic space opera film directed by George Lucas. The story follows a young farm boy named Luke Skywalker, who teams up with a rogue pilot and a pair of droids to rescue Princess Leia, the leader of the Rebel Alliance, from the clutches of the evil Empire.";
            break;
        case '2':
            document.getElementById(spanID).innerText = "Star Wars Episode V: The Empire Strikes Back is a 1980 American epic space opera film directed by Irvin Kershner. The story continues to follow the journey of Luke Skywalker, Princess Leia, and Han Solo as they battle against the evil Galactic Empire. In this chapter of the saga, the Empire has launched a major attack against the Rebel Alliance, forcing them to flee their base on the icy planet of Hoth. Meanwhile, Luke travels to the swamp planet of Dagobah to train with Jedi Master Yoda, while Han and Leia are pursued by Darth Vader and the Empire. The film features some of the most iconic moments in the Star Wars franchise, including the revelation of a major character's true identity.";
            break;
        case '3':
            document.getElementById(spanID).innerText = "Star Wars Episode VI: Return of the Jedi is a 1983 American epic space opera film directed by Richard Marquand. The story picks up one year after the events of The Empire Strikes Back, with the Rebel Alliance planning to launch a final attack against the Empire's new and improved Death Star. Meanwhile, Luke Skywalker attempts to rescue Han Solo from the clutches of the gangster Jabba the Hutt, and confronts Darth Vader in a final showdown. The film features a thrilling space battle sequence, as well as an emotional conclusion to the original Star Wars trilogy.";
            break;
        case '4':
            document.getElementById(spanID).innerText = "Star Wars Episode I: The Phantom Menace is a 1999 American epic space opera film directed by George Lucas. The story takes place 32 years before the events of the original Star Wars film, and follows Jedi Knight Qui-Gon Jinn and his Padawan Obi-Wan Kenobi as they attempt to negotiate peace between the planet Naboo and the Trade Federation. Along the way, they encounter a young boy named Anakin Skywalker, who they believe to be the Chosen One destined to bring balance to the Force. The film also introduces the character of Darth Maul, a deadly Sith Lord with a double-bladed lightsaber. Despite mixed critical reception upon release, The Phantom Menace went on to become a box office success and a cultural phenomenon.";
            break;
        case '5':
            document.getElementById(spanID).innerText = "Star Wars Episode II: Attack of the Clones is a 2002 American epic space opera film directed by George Lucas. The story takes place 10 years after the events of The Phantom Menace, and follows Jedi Knight Obi-Wan Kenobi and his Padawan Anakin Skywalker as they investigate an assassination attempt on Senator Padmé Amidala. As they delve deeper into the mystery, they uncover a larger conspiracy involving a separatist movement and a secret army of clones. The film also explores the growing relationship between Anakin and Padmé, as well as the origins of the Clone Wars that were referenced in the original Star Wars trilogy. The film was a box office success, but received mixed reviews from critics and audiences alike.";
            break;
        case '6':
            document.getElementById(spanID).innerText = "Star Wars Episode III: Revenge of the Sith is a 2005 American epic space opera film directed by George Lucas. The story takes place three years after the events of Attack of the Clones, and follows Jedi Knight Anakin Skywalker as he is seduced by the dark side of the Force and becomes the Sith Lord Darth Vader. The film also depicts the final days of the Clone Wars and the fall of the Galactic Republic, as well as the rise of the Galactic Empire and the purge of the Jedi Order. The film features several iconic moments, including the duel between Anakin and his former mentor Obi-Wan Kenobi on the volcanic planet of Mustafar. Despite mixed critical reception, Revenge of the Sith was a box office success and was praised for its visual effects and action sequences.";
            break;

    }

}

