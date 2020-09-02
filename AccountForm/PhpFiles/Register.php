<?php
include_once 'helper.php'; //include the helper php

$db = DBConnect(); //create a connection to the database

$user = $_GET['user']; //get the username
$password= $_GET['password']; //get the password
$salt = $_GET['salt']; //get the salt

//add the salt to the password
$saltedPass = $password . $salt;
/create the hash with the salted password
$hash = password_hash($saltedPass, PASSWORD_DEFAULT);

//add it to the database
$sql = "INSERT INTO users (user, hash, salt)
VALUES ('$user', '$hash', '$salt')";

$result = $db->query($sql);

if($result)
echo 'TRUE';
else
echo 'FALSE';

?>