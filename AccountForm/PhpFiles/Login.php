<?php
include_once 'helper.php'; //include the helper php

$db = DBConnect(); //create the conection to the database

$user = $_GET['user']; //the username
$password = $_GET['password']; //the password

$getInfo = "SELECT * FROM users WHERE user='$user'";

$result = $db->query($getInfo);

if ($result->num_rows > 0) {
 
  while($row = $result->fetch_assoc()) 
  {
   
   $hash = $row['hash']; //gets the hash
   $salt = $row['salt']; //gets the salt
   
   $saltedPass = $password . $salt; //adds the salt to the password

   //compares the salted pass to the hash
  if (password_verify($saltedPass, $hash)) {
    echo 'TRUE';
}
else {
    echo 'FALSE';
}
  }
} else 
  echo 'FALSE';

?>