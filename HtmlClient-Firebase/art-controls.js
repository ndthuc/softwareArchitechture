const config = { databaseURL: "https://tin415de01art.firebaseio.com/" }
firebase.initializeApp(config);
const dbRef = firebase.database().ref();

function page_load() {
    getAll();
}

function getAll() {
    dbRef.child("artItems").on("value", (snapshot) => {
        var artItems = [];
        snapshot.forEach((child) => {
            var artItem = child.val();
            artItems.push(artItem);
        });
        renderArtItemsList(artItems);
    });
}

function renderArtItemsList(items) {
    var header = "<tr><th>Code</th><th>Name</th><th>Category</th><th>Price</th><th>Brand</th></tr>";
    var rows = "";
    for (var item of items) {
        rows += "<tr onclick='viewDetails(" + item.Code + ")' style='cursor:pointer'>";
        rows += "<td>" + item.Code + "</td>";
        rows += "<td>" + item.Name + "</td>";
        rows += "<td>" + item.Category + "</td>";
        rows += "<td>" + item.Price + "</td>";
        rows += "<td>" + item.Brand + "</td>";
        rows += "</tr>";
    }
    document.getElementById("listItems").innerHTML = header + rows;
}

function viewDetails(code) {
    getItemDetails(code);
}

function getItemDetails(code) {
    dbRef.child("artItems").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var artItem = child.val();
            if (artItem.Code == code) {
                document.getElementById("Code").value = artItem.Code;
                document.getElementById("Name").value = artItem.Name;
                document.getElementById("Category").value = artItem.Category;
                document.getElementById("Price").value = artItem.Price;
                document.getElementById("Brand").value = artItem.Brand;
            }
        });
    });
}

function addNewItem() {
    var newItem = {
        "Code": document.getElementById("Code").value,
        "Name": document.getElementById("Name").value,
        "Category": document.getElementById("Category").value,
        "Price": document.getElementById("Price").value,
        "Brand": document.getElementById("Brand").value
    };
    dbRef.child("artItems/art" + newItem.Code).set(newItem);
}

function updateItem() {
    var code = document.getElementById("Code").value;
    var updatedItem = {
        Code: code,
        Name: document.getElementById("Name").value,
        Category: document.getElementById("Category").value,
        Price: document.getElementById("Price").value,
        Brand: document.getElementById("Brand").value,
    };
    dbRef.child("artItems").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var item = child.val();
            if (item.Code == updatedItem.Code) {
                var key = child.key;
                dbRef.child("artItems").child(key).set(updatedItem);
            }
        });
    });
}

function deleteItem() {
    if (confirm("Are you sure?")) {
        var code = document.getElementById("Code").value;
        dbRef.child("artItems").once("value", (snapshot) => {
            snapshot.forEach((child) => {
                var item = child.val();
                if (item.Code == code) {
                    var key = child.key;
                    dbRef.child("artItems").child(key).remove();
                }
            });
        });
    }
}

function searchItems() {
    var keyword = document.getElementById("Keyword").value;

    dbRef.child("artItems").once("value", (snapshot) => {
        var artItems = [];
        snapshot.forEach((child) => {
          var artItem = child.val();
          if (artItem.Name.includes(keyword)) {
            artItems.push(artItem);
          }
        });
        renderArtItemsList(artItems);
      });
}

