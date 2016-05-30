<?php
require_once('config.php');
//IF GET LIST_USERS THEN CONTINUE
if(isset($_GET['list_users']) and $_GET['list_users']=='fuckingtrue'){ 
if(isset($_GET['key'])) {
$key = $connect->real_escape_string($_GET['key']);

$query = mysqli_query($connect,"SELECT * FROM data WHERE license_key='".$key."'");
$row_cnt = $query->num_rows;
}else{
	die('FUCK OFF');
}
if($row_cnt <= 0) { exit('WRONG KEY OR NO KEYS EXIST'); }
	while($fetch = mysqli_fetch_array($query)) 
	{
		echo $fetch['stub'];	
	}
 }//END LIST USERS 
?>