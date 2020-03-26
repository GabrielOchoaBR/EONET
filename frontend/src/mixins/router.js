export default {
    data() {
        return {
            nameSearch: '',
            resultSeach: null
        }
    },
    methods: {
        routeFindByName(name) {
            let routes = this.$router.options.routes;

            this.nameSearch = name;

            routes.forEach(this.routeFindHelper);

            let result = this.resultSeach;
            
            this.resultSeach = null;

            return result;
        },
        routeFindHelper(route) {

            if (this.resultSeach != null)
                return null;
            
            else if (route.name == this.nameSearch)
                this.resultSeach = route;
            
            else if(route.children != null && route.children.length > 0) {
                let routes = route.children;

                routes.forEach(this.routeFindHelper);
            }
        }
            
        
    }
}