<?php
$name 		= strip_tags($_POST['name']);
$email 		= strip_tags($_POST['email']);
$message 	= $_POST['message'];
if (!empty($name) && !empty($email) && !empty($message) && filter_var($email, FILTER_VALIDATE_EMAIL))
{
	$to 	= "somebody@example.com"; // YOUR EMAIL
	$subject = "Contact form";
	$headers = "From: " . strip_tags($email) . "\r\n";
	$headers .= "Reply-To: ". strip_tags($email) . "\r\n";
	$headers .= "MIME-Version: 1.0\r\n";
	$headers .= "Content-Type: text/html; charset=UTF-8\r\n";
	$txt 	= wordwrap("<p>You have a message from: $name and his e-mail is ".$email."<br><br>".$message."</p>",70);
	mail($to,$subject,$txt,$headers);
}
if(isset($_SERVER['HTTP_REFERER'])) {
    $previous = $_SERVER['HTTP_REFERER'];
	exit();
}
header("location:javascript://history.go(-1)");
?> 