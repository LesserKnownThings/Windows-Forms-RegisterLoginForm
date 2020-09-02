# Windows-Forms-RegisterLoginForm
<h2> Windows form that has two functions. Register; which registers the user to the database with a secure password (adding a salt and hashing it). Login; which logs the user in the account. </h2>

<h1> BEFORE YOU TRY THIS PROJECT! </h1>

<a style="font-size=25px"> There are a couple of things that you need to do: </a>
<br>
<ul>
<li><a href="#create">Create a database</a></li>
<li><a href="#server">Have a server to run php</a></li>
<li><a href="#project">Add the uri to the project</a></li>
<li><a href="#stress">Don't Stress</a></li>
</ul>

<br>
<br>

<h2 id="create">Create a database</h2>

<a>You'll have to create a database and add a table named <a style="font-weight=bold">users</a> with 3 columns <a style="font-weight=bold"> User, Hash, Salt. </a>You can add other columns as well, but you'll have to change the php scripts as well.</a>

<br>
<br>

<h2 id="server">Create Server</h2>
<a>You'll need a server to run the php scripts and connect to the database. The php scripts are located in the AccountForm/PhpFiles. You will need to add a couple of things in the <a style="font-weight=bold">helper.php</a> script, open it up and you'll notice exactly what. After you added the needed things to the script, you will have to add the scripts to your server.</a>

<br>
<br>

<h2 id="project">Add the uri to the project</h2>
<a> If you want to change the files before opening the project go to <a style="color=blue"> AccountForm/AccountForm/Scripts/Misc/GlobalValues.cs<a> and add the uri to the php uri's so that they can connect to the php and send the values. Or you can just open the project and do the same thing from the Scripts/Misc/GlobalValues.cs script.</a>

<h2 id="stress">Don't stress</h2>
<a>If you have any questions you can always contact me <a href="https://twitter.com/things_lesser">here</a> or <a href="https://www.facebook.com/ursu.l.marius">here</a>.</a>
