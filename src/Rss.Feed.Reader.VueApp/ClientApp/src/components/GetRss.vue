<template>
    <h1 id="tableLabel">Get RSS</h1>

    <p>This component demonstrates fetching data from the server.</p>

    <p v-if="!channel"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="channel">
        <thead>
            <tr>
                <th>Posts</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item of channel.items" v-bind:key="item">
                <td>{{ item.title }}</td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "GetRss",
        data() {
            return {
                channel: {}
            }
        },
        methods: {
            getRss() {
                axios.get('/rss')
                    .then((response) => {
                        this.channel =  response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getRss();
        }
    }
</script>