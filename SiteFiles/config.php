<?php
$connect=mysqli_connect("localhost","root","","crypter");
if (mysqli_connect_errno())
  {
  echo "MySQL can't connect" . mysqli_connect_error();
  }
?>