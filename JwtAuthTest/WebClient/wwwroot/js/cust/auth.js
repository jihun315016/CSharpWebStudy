// ������ ���� - Application - Local storage �Ǵ� Session storage���� ��ū Ȯ�� ����
sessionStorage.setItem('jwtToken', '@Model');

$.ajaxSetup({
    beforeSend: function (xhr) {
        xhr.setRequestHeader('Authorization', 'Bearer ' + sessionStorage.getItem('jwtToken'));
    }
});
