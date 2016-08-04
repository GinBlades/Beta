var gulp = require("gulp"),
    plumber = require("gulp-plumber"),
    sass = require("gulp-sass"),
    maps = require("gulp-sourcemaps"),
    uglify = require("gulp-uglify"),
    concat = require("gulp-concat");

gulp.task("sass", () => {
    return gulp.src("./wwwroot/src/**/*.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest("./wwwroot/css"));
});

gulp.task("vendorJs", () => {
    let vendorFiles = [
        "./wwwroot/lib/jquery/dist/jquery.js",
        "./wwwroot/lib/bootstrap-sass/assets/javascripts/bootstrap.js"
    ];

    return gulp.src(vendorFiles)
        .pipe(plumber())
        .pipe(maps.init())
        .pipe(uglify())
        .pipe(concat("app.js"))
        .pipe(maps.write("."))
        .pipe(gulp.dest("./wwwroot/js"));
});

gulp.task("copyFonts", () => {
    return gulp.src("./wwwroot/lib/bootstrap-sass/assets/fonts/**/*")
        .pipe(gulp.dest("./wwwroot/fonts"));
});

gulp.task("init", ["vendorJs", "copyFonts"]);

gulp.task('default', ["sass"]);