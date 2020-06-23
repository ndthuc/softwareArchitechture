

const cors = "https://cors-anywhere.herokuapp.com/";
const domain = "http://tin415de01.gear.host/"

function page_load() {
    getAll();
}

function getAll() {
    axios.get(cors + domain + "api/arts").then((res) => {
        var artItems = res.data;
        renderArtItemsList(artItems);
    })
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
    axios.get(cors + domain + "api/arts/" + code)
        .then((res) => {
            var artItem = res.data;
            document.getElementById("Code").value = artItem.Code;
            document.getElementById("Name").value = artItem.Name;
            document.getElementById("Category").value = artItem.Category;
            document.getElementById("Price").value = artItem.Price;
            document.getElementById("Brand").value = artItem.Brand;
        });
}

function addNewItem() {
    var newItem = {
        "Code": 9,
        "Name": document.getElementById("Name").value,
        "Category": document.getElementById("Category").value,
        "Price": document.getElementById("Price").value,
        "Brand": document.getElementById("Brand").value
    }
    axios.post(cors + domain + "api/arts", newItem)
        .then((res) => {
            var result = res.data;
            if (result) {
                alert("Add Successful!!!");
                getAll();
            } else {
                alert("sorry, something wrong!!! can`t add new item!!!");
            }
        });
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

    axios.put(cors + domain + "api/arts/" + code, updatedItem)
        .then((res) => {
            var result = res.data;
            if (result) {
                alert("Update Successful!!!");
                getAll();
            } else {
                alert("sorry, something wrong!!! can`t update item!!!");
            }
        });
}

function deleteItem() {
    if (confirm("Are you sure?")) {
        var code = document.getElementById("Code").value;
        axios.delete(cors + domain + "api/arts/" + code)
            .then((res) => {
                var result = res.data;
                if (result) {
                    alert("Delete Successful!!!");
                    getAll();
                } else {
                    alert("sorry, something wrong!!! can`t delete item!!!");
                }
            });
    }
}

function searchItems() {
    var keyword = document.getElementById("Keyword").value;

    if (keyword.length > 0) {
        axios.get(cors + domain + "api/arts/search/" + keyword)
            .then((res) => {
                var items = res.data;
                renderArtItemsList(items);
            });
    } else {
        getAll();
    }
}
