// Write your JavaScript code.
$(function(){

    // var myElements = document.getElementsByTagName("div");
    // // console.log(myElement.innerHTML);
    // // alert("I'm ready now, let's go!");
    // var elementString = "";

    // for (var i = 0; i < myElements.length; i++){
    //     elementString += `${myElements[i].innerHTML}\n=======\n`;
    // }
    // console.log(`Total elements: ${ myElements.length }`)
    // console.log(elementString);

    // var myStuff = document.querySelectorAll("div p #id");
    // var myOtherStuff = document.querySelectorAll("#id");

    var footerElement = document.getElementsByTagName("footer")[0];
    var newDiv = document.createElement("div");
    newDiv.innerHTML = "Here is a new <code>&lt;div&gt;</code> element in a <code>&lt;footer&gt;</code> element.";
    footerElement.appendChild(newDiv);

    console.log(footerElement);
});