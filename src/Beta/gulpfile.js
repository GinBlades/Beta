var gulp = require('gulp'),
    sass = require("gulp-sass");

gulp.task("sass", () => {
    return gulp.src("./wwwroot/src/**/*.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest("./wwwroot/css"));
})

gulp.task('default', ["sass"]);