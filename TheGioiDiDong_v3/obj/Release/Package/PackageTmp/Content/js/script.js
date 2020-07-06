//form Goi Lại(ho tro khach hang)
function checkSubmitGoiLai(){
	var ht=frmGoiLai.hoten.value;
	var sdt=frmGoiLai.sdt.value;
	if(isNaN(ht)==false)
	{
		alert('Ban nhập sai định dạng Họ Tên !');
		document.frmGoiLai.hoten.value="";
		return false;
	}
	if(isNaN(sdt)==true)
	{
		alert('Bạn nhập sai định dạng Số điện thoại !!')
		document.frmGoiLai.sdt.value="";
		return false;
	}
	alert('Gửi nội dung thành công. Chúng tôi sẽ hỗ trợ trong thời gian sớm nhất \n Thân.');
	return true;
}
//form Tìm kiếm ở Index
function checkTimKiemIndex(){
	var tk= frmTimKiemIndex.TimKiem.value;
	if(tk==""){
		alert('Bạn chưa nhập nội dung để Tìm kiếm !!');
		document.frmTimKiemIndex.TimKiem.focus();
		return false;
	}
}
//form Đăng ký
function checkSubmitDangKy(){
	var em=dangky.email.value;
	var mk=dangky.matkhau.value;
	var nlmk=dangky.nhaplaimatkhau.value;
	var sdt=dangky.dienthoai.value;
	if(isNaN(sdt)==true){
		alert('Bạn phải nhập Số điện thoại là số');
		document.dangky.dienthoai.value="";
		document.dangky.dienthoai.focus();
		return false;
	}
	if(nlmk!=mk)
	{
		alert("Nhập lại mật khẩu sai");
		document.dangky.nhaplaimatkhau.value="";
		document.dangky.nhaplaimatkhau.focus();
		return false;
	}
	alert('Đăng ký thành công !!');
	return true;
}
function hien(){
		document.getElementById('pass').type="text";	
}
function an(){
		document.getElementById('pass').type="password";
}

//form Đăng ký nhận tin khuyến mãi
function checkSubmitNhanKM(){
	alert('Đăng ký Email nhận khuyến mãi thành công !');
	return true;
}
//Timer
var myvar=setInterval(myTimer,1000);
function myTimer(){
	var d=new Date();
	document.getElementById('time').innerHTML=d.toLocaleTimeString();
}
