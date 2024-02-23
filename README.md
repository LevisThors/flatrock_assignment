<h1>How it works?</h1>
<ul>ProductHtml class has a static method - GetHtml, which returns the data that needs to be parsed.</ul>
<ul>ExtractProduct's Extract class uses HtmlAgilityPack. It reads the text and creates Products based on it.</ul>
<ul>We iterate over the list of products which Extract method returned and writing product properties to console.</ul>
