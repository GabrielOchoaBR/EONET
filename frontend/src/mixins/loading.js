import alerts from '../common/alerts.js';

export default {
    data() {
        return {
            waiting: null,
            timeUntillMasked: 1 * 1000 //1 seg.
        }
    },
    methods: {
        open() {
            this.waiting = setTimeout(() => this.$loading(true), this.timeUntillMasked);
        },
        close() {
            clearTimeout(this.waiting);
            
            this.$loading(false);
            
            setTimeout(() => this.$loading(false), this.timeUntillMasked);
        },
        async loadingPromises(promises) {
            this.open();
            try {
                return await Promise.all(promises);
            } catch (e) {

                alerts.showError('Unexpected error', 'Please, report the problem in go@gabrielochoa.me  - ' + e.message);
                
            } finally {
                this.close();
            }
        },
    }
}