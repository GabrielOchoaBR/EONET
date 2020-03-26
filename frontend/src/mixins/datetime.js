import moment from 'moment';

export default {
    methods: {
        dateIso(date){
            return date ? moment(date).format(this.FORMATO_ISO) : null;
        },
        dateFormat(date, placeholderNull = "") {
            return date ? moment(date).format(this.FORMATO_DATE) : placeholderNull;
        },
    },
    computed: {
        FORMATO_ISO() { return moment.HTML5_FMT.DATE; },
        FORMATO_DATE() { return 'L'; },
    }
}
