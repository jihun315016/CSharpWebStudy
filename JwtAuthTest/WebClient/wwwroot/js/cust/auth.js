// 개발자 도구 - Application - Local storage 또는 Session storage에서 토큰 확인 가능
sessionStorage.setItem('jwtToken', '@Model');

$.ajaxSetup({
    beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', 'Bearer ' + sessionStorage.getItem('jwtToken'));
    }
});
