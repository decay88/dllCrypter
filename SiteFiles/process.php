<?php
include("config.php");
//$id = $connect->real_escape_string($_POST['id']);
$column = "stub";//$connect->real_escape_string($_POST['column']);
$data = $connect->real_escape_string($_POST['stub']);// $connect->real_escape_string($_POST['data']);
$license_key = $connect->real_escape_string($_POST['license_key']);
$stub = $connect->real_escape_string($_POST['stub']);
if(isset($_POST['expire'])){
$expire = $connect->real_escape_string($_POST['expire']);
}
//UPDATE DATA ENTRIES
if(isset($_POST['update'])){
if(($_POST['license_key']) and $_POST['stub'])
{
if($column=='stub') 
{ 

$query = mysqli_query($connect,"SELECT * FROM data WHERE license_key='".$license_key."'");
$row_cnt = $query->num_rows;

	while($fetch = mysqli_fetch_array($query)) 
	{
		if($fetch['expire'] == 0) { exit('USER IS EXPIRED NEEDS MORE STUBS'); }
		$minus = $fetch['expire'] - 1;
		mysqli_query($connect,"update data set expire = $minus");
	}
} 

if ($query = $connect->prepare("update data set $column = ? where license_key = ?")) {
 
    // Bind the variables to the parameter as strings. 
    $query->bind_param("ss", $data, $license_key);
 
    // Execute the statement.
    $query->execute();
 
    // Close the prepared statement.
    $query->close();	
}

	echo 'success';
}
}


//ADD ROW ENTRY
if(isset($_POST['add']))
{ 
$sql = "INSERT INTO data (license_key, stub, expire)
VALUES ('".$license_key."', '".$stub."', '".$expire."')";
if ($connect->query($sql) === TRUE) {
    echo 'success';
} else {
    echo "Error: " . $sql . "<br>" . $connect->error;
}
}

//DELETE ROW ENTRY
if(isset($_POST['delete']))
{ 
if ($query = $connect->prepare("DELETE FROM data WHERE license_key = ?")) {
 
    // Bind the variable to the parameter as a string. 
    $query->bind_param("s", $license_key);
 
    // Execute the statement.
    $query->execute();
 
    // Close the prepared statement.
    $query->close();
}
}
?>