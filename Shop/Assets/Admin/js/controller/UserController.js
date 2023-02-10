﻿var user = {
    init: function () {
        user.register();
    },

    register: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.text('True');
                    } else {
                        btn.text('False');
                    }
                }
            });
        });
    }
}
user.init();