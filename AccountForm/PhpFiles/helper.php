<?php

function DBConnect(){
$servername = "" //The servername of your database
$username = "";  //The user of the database you want to use
$db_password = ""; //The database password
$dbname = ""; //The database name
 
//This creates a connection to the database
$conn = new mysqli($servername, $username, $db_password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
  return null;
}else
return $conn;
}

?>