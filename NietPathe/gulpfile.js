
var gulp = require("gulp"),
  sass = require("gulp-sass");

gulp.task("sass", function () {
  return gulp.src('wwwroot/scss/main.scss')
    .pipe(sass())
    .pipe(gulp.dest('wwwroot/css'));
});

gulp.task( 'default', [ 'sass' ] )
