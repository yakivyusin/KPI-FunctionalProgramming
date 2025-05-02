import { defineConfig } from "vite";

// https://vitejs.dev/config/
export default defineConfig({
    build: {
        outDir: "../../deploy/public",
    },
    server: {
        port: 8080,
        watch: {
            ignored: [ "**/*.fs" ]
        },
    }
});
