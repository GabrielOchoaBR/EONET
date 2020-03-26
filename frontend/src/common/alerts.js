import swal from 'sweetalert2';

export default {
    clearErrorMessage(detail) {
        if (!detail) {
            return undefined;
        }
        let parent = detail.response ? detail.response.data : detail;
        return parent.exceptionMessage || parent.message || parent;
    },
    async showError(titulo = 'Something went wrong', detail = null) {
        await swal.fire(
            {
                title: titulo,
                html: this.clearErrorMessage(detail),
                icon: 'error'
            }
        )
    },
}
