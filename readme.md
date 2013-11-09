# Go Team Ponies!
####Check out our site @ (http://ponies.azurewebsites.net/)

We are a team destined for greatness. Or pizza. One of the two.

### We are:
+ Max Fox (What does the fox say?)
+ Ken (What _does_ he say?
+ Mohsin (Nothing. He says nothing.)
+ Josh Wilson (How should I know?) 
+ Mark L ([Ring-ding-ding-ding-dingeringeding!](http://www.metrolyrics.com/the-fox-lyrics-ylvis.html))
+ Test add

###Some links to check out

1. [D&B Android app](https://play.google.com/store/apps/details?id=com.dandb.app.creditreporter)
2. [D&B iPhone app](https://itunes.apple.com/us/app/credit-reporter-by-dun-bradstreet/id661843054)
3. [D&B Dev Docs](http://developer.dnb.com/docs)
4. [Hackathon link](https://dnbdctech.eventbrite.com/)
5. [D&B Products and Features](http://developer.dnb.com/docs/2.0/products-and-features)
	+ Products and Features lists all available data types from D&B
6. [D&B Data Categories](http://developer.dnb.com/docs/2.0/data-categories)
	+ Data Categories lists products grouped according to their data catagory/layer


###Some thoughts/App Ideas
+We will be making something that allows the user to find similar companies to a company whose DUNS number they enter. 
They will be able to find different companies based on different sets of metrics.(Financial, Social, Etc.) based on different metrics.


+ Using Glass for the hackathon
	+ Would you guys like to use Glass in the hackathon as part of the App? They have an Android/iOS app, but not a Glass one...

###Some code samples

```javascript
var authToken;

var fnAuthenticate = function() {
	$.ajax({
		url: "https://maxcvservices.dnb.com/rest/Authentication",
		type: "POST",
		date: {
			"x-dnb-user": "ken.kopczyk@gmail.com",
			"x-dnd-pwd": "sandbox",
		},
		success: function(data, textStatus, jqXHR) {
			authToken = data.Authorization;		
			console.log("SUCCESS!");
		},
		error: function(jqXHR, textStatus, errorThrown) {
			console.log("FAILURE!");
		}
	});	
}
```

### APIs to focus on:

+ Money related
+ Fraud/Overview related
+ Business connections related
